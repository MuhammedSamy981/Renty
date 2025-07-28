import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/services/users.service';
import { ForgotPasswordDto } from 'src/app/types/user/ForgotPasswordDto';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {


  constructor(private usersService:UsersService) {}

  forgotPasswordForm=new FormGroup({
    email: new FormControl<string>('',[
      Validators.email,
      Validators.required
    ])
  });

resetPassword(e: Event) {

            e.preventDefault();
            if (this.forgotPasswordForm.invalid) return;
      const forgotPassword:ForgotPasswordDto=
      {
        email:this.forgotPasswordForm.value.email!
      };
      this.usersService.forgotPassword(forgotPassword).subscribe({
        next:()=> 
        {
              alert("Resst password mail was sent");     
  
        },
        error:()=> {
          alert("failed to sent resst password mail ");
        },
      });
}
}
