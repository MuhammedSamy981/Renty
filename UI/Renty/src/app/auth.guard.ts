
import { Injectable } from '@angular/core';
import {CanActivate,Router,ActivatedRouteSnapshot,RouterStateSnapshot} from '@angular/router';
import { UsersService } from './services/users.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private usersService: UsersService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    
    const requiredRoles = route.data['roles'] as Array<string>;

     const token = localStorage.getItem('token');
    if (token){
                      if (!requiredRoles || this.usersService.hasAnyRole(requiredRoles)) {
        return true;
      }
      else{
      this.router.navigate(['/unusersServiceorized']);
      return false;
    }
    } else {
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
  }
}