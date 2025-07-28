import { Component } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';
import { ResetPasswordDto } from 'src/app/types/user/ResetPasswordDto';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent  {
  email?: string;
  token?: string;

  
constructor(private route: ActivatedRoute,private usersService:UsersService) {}

ngOnInit() {
  this.route.queryParams.subscribe(params => {
    console.log(params['email']); 
    console.log(params['token']); 
   this.email= params['email']; 
   this.token=params['token']; 
  });
}
 restPasswordForm = new FormGroup({
         password: new FormControl<string>('', [
            Validators.required,
            Validators.minLength(8)
          ]),
          confirmPassword: new FormControl<string>('', [
            Validators.required,
          ])}
          ,{ validators: this.passwordsMatchValidator });



  // Custom validator
  passwordsMatchValidator(group: AbstractControl): ValidationErrors | null {
    const password = group.get('password')?.value;
    const confirm = group.get('confirmPassword')?.value;
    return password === confirm ? null : { passwordsMismatch: true };
  }
  
  save(e: Event): void {
          e.preventDefault();
          if (this.restPasswordForm.invalid) return;
    const reset:ResetPasswordDto=
    {
      email: this.email!,
      token: this.token!.replaceAll(" ", "+"),
      newPassword: this.restPasswordForm.value.password!
    };
    console.log(reset);
    this.usersService.resetPassword(reset).subscribe({
      next:()=> 
      {
        alert("Resst done");     
      },
      error:()=> {
        alert("Resst failed");
      },
    });




  }

}