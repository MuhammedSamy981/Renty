import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';
import { LoginDto } from 'src/app/types/user/LoginDto';
import { SocialLoginDto } from 'src/app/types/user/SocialLoginDto';
declare const FB: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
submitted?: boolean;
  //UserDetails?:UserDetailsDTO;
  ErrorCode: number = 101;
  loginform = new FormGroup({
    email: new FormControl<string>('', [
      Validators.email,
      Validators.required
    ]
    ),
    password: new FormControl<string>('', [
      Validators.required
    ]
    )
  })
  

  constructor(private usersService: UsersService, private router: Router) { }
  ngOnInit(): void {

    FB.init({
      appId: '1183691906890141',
      cookie: true,
      xfbml: true,
      version: 'v23.0'
    });


    // @ts-ignore
    google.accounts.id.initialize({
      client_id: "390034936107-217hig7jih4vfuacuag1auci3eq2l6mn.apps.googleusercontent.com",
      callback: this.handleCredentialResponse.bind(this),
      auto_select: false,
      cancel_on_tap_outside: true,
    });

    // @ts-ignore
    google.accounts.id.renderButton(
      // @ts-ignore
      document.getElementById("google-button"),
      { theme: "outline", size: "large", width: "100%" }
    );

  }

  Login(): void {
    if (this.loginform.invalid) {
      this.submitted = true; 
      return;
    }
    this.submitted = false;
    const login: LoginDto = {
      email: this.loginform.value.email!,
      password: this.loginform.value.password!,
    }
    console.log(login)
    this.usersService.login(login).subscribe(
      {
        next: () => {
          if(this.usersService.hasAnyRole(['Admin','Manager']))
            {
              this.router.navigateByUrl("/admin")
            .then(() => {
              window.location.reload();
            });
            }

            else
              {
          this.router.navigateByUrl("/")
            .then(() => {
              window.location.reload();
            });
          }
        },
        error: (error) => {
          this.ErrorCode = error["status"];
        },
      }
    )
  }


  loginWithFacebook(): any {
    FB.getLoginStatus((response: any) => {   // See the onlogin handler
      if (response.status === 'connected') {
        console.log('youre already login');
      }
      else {
        FB.login((response: any) => {
          if (response.authResponse) {
            FB.api('/me',{ fields: 'id,name,email,first_name,last_name' }, (response: any) => {
                  const login: SocialLoginDto = {
                    firstName: response.first_name,
                    lastName: response.last_name,
                    email: response.email==undefined?
                    "User" + response.id + "@renty.com":response.email,
                    phoneNumber: 'undefined',
                    countryId: 1,
                    cityId: 1,
                    areaId: 1
                  }
console.log(login)
    this.usersService.loginSocial(login).subscribe(
      {
        next: () => {
          this.router.navigateByUrl("/")
            .then(() => {
              window.location.reload();
            });
        },
        error: (error) => {
          this.ErrorCode = error["status"];
        },
      }
    )
              console.log('Successful login for: ' + response.name)
            });
          }
          else {
            console.log('User cancelled login or did not fully authorize.');
          }

        }, { scope: 'public_profile,email' });
      }

    });




  }





  handleCredentialResponse(response: any): void {

    console.log("Encoded JWT ID token: " + response.credential);

    const responsePayload = this.decodeJWT(response.credential);

                      const login: SocialLoginDto = {
                    firstName: responsePayload.given_name,
                    lastName: responsePayload.family_name,
                    email: responsePayload.email==undefined?
                    "User" + responsePayload.id + "@renty.com":responsePayload.email,
                    phoneNumber: 'undefined',
                    countryId: 1,
                    cityId: 1,
                    areaId: 1
                  };
console.log(login);
    this.usersService.loginSocial(login).subscribe(
      {
        next: () => {
          this.router.navigateByUrl("/")
            .then(() => {
              window.location.reload();
                  console.log("  Full Name: " + responsePayload.name);
            });
        },
        error: (error) => {
          this.ErrorCode = error["status"];
        },
      }
    )
  }

  decodeJWT(token: any): any {

    let base64Url = token.split(".")[1];
    let base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
    let jsonPayload = decodeURIComponent(
      atob(base64)
        .split("")
        .map(function (c) {
          return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join("")
    );
    return JSON.parse(jsonPayload);
  }




}
