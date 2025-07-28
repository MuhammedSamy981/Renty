import { Component } from "@angular/core";
import { UsersService } from "./services/users.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

constructor(private usersService: UsersService,private router:Router){}

      logOut():void
      {
        this.usersService.logout();
          this.router.navigate([this.router.url])
    .then(() => {
      window.location.reload();
    });
      }
}