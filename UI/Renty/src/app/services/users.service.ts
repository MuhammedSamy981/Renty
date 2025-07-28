import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AccountUpdateDto } from "../types/user/AccountUpdateDto";
import { LoginDto } from "../types/user/LoginDto";
import { RegisterDto } from "../types/user/RegisterDto";
import { BehaviorSubject, Observable, Subject, tap } from "rxjs";
import { UserDto } from "../types/user/UserDto";
import {jwtDecode} from 'jwt-decode';
import { SocialLoginDto } from "../types/user/SocialLoginDto";
import { ForgotPasswordDto } from "../types/user/ForgotPasswordDto";
import { ResetPasswordDto } from "../types/user/ResetPasswordDto";

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private apiUrl = "http://localhost:5214/odata/Users";
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) 
  {
//  this.currentUserSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('currentUser') || '{}'));

    this.loggedIn.next(!!localStorage.getItem('access_token'));
   }


  // const headers = new HttpHeaders({
 // 'Authorization': `Bearer ${localStorage.getItem('jwt')}`
//});

//this.http.get('/api/secure-data', { headers }).subscribe(...);



 // getUserInfo() {
   // const decodedToken = this.getDecodedAccessToken();
   // if (decodedToken) {
    //  return {
       // userId: decodedToken.userId,
     //   email: decodedToken.email,
      //  roles: decodedToken.roles
     // };
  //  }
   // return null;
 // }

  public getUserId():string
  {
     const token = localStorage.getItem('access_token');
     console.log(token);
    const decodedToken = jwtDecode(token!);

    return decodedToken.jti!;
  }

    public getUserPhoneNumber():string
  {
     const token = localStorage.getItem('access_token');
    const decodedToken = jwtDecode(token!);
        return decodedToken.aud?.at(0)!;
  }
 

  public getUser():Observable<UserDto>
  {
    return this.http.get<UserDto>(this.apiUrl+"/CurrentUserInfo");
  }
  

  login(UserLogin: LoginDto): Observable<object> {
    return this.http.post<{ accessToken: string , refreshToken: string }>(this.apiUrl+"/Login", UserLogin) 
    .pipe(
      tap(response => {
        localStorage.setItem('access_token', response.accessToken);
    localStorage.setItem('refresh_token', response.refreshToken);
        this.loggedIn.next(true);
      })
    );
  }

    loginSocial(UserLogin: SocialLoginDto): Observable<object> {
    return this.http.post<{ accessToken: string , refreshToken: string  }>(this.apiUrl+"/SocialLogin", UserLogin) 
    .pipe(
      tap(response => {
         localStorage.setItem('access_token', response.accessToken);
    localStorage.setItem('refresh_token', response.refreshToken);
        this.loggedIn.next(true);
      })
    );
  }


  
  refreshToken(): Observable<any> {
    const refreshToken = localStorage.getItem('refresh_token');
    return this.http.post(this.apiUrl+"/refresh-token", { refreshToken });
  }
  
  forgotPassword(forgotPassword: ForgotPasswordDto): Observable<object> {
    return this.http.post(this.apiUrl+"/forgot-password",forgotPassword);
  }

    resetPassword(resetPassword: ResetPasswordDto): Observable<object> {
    return this.http.post(this.apiUrl+"/reset-password",resetPassword);
  }

  logout() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    this.loggedIn.next(false);
  }

 
  hasAnyRole(roles:Array<string>):boolean
  { 
     const token = localStorage.getItem('access_token');
     if(token!=null){
    const decodedToken = jwtDecode(token);
          for(let i =0;i<roles.length;i++){
    const h=decodedToken.aud?.at(0);
    console.log(h);
             if(decodedToken.sub==roles[i])
              {
                console.log("jjjjjjjj"+decodedToken.sub);
              return true;
              }
          }  
}
              
            
    return false;
  }
 

  isLoggedIn() {
    return this.loggedIn.asObservable();
  }


  register(UserRegister: RegisterDto): Observable<object> {
    return this.http.post(this.apiUrl+"/Register", UserRegister);
  }


  accountUpdate(UserDetails: AccountUpdateDto): Observable<object> {
    return this.http.put(this.apiUrl+"/AccountUpdate", UserDetails);
  }

 /*

  RegisterAdmin(UserRegister: UserAddDTO): Observable<any> {
    return this.http.post<string>(`this.apiUrl+"/Admin/Register`, UserRegister);
  }
  */

}
