import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Login } from 'src/app/models/login';
import { Response, ResponseData } from 'src/app/models/response';

@Injectable({
  providedIn: 'root',
})
export class AuthenticateService {
  helper = new JwtHelperService();

  constructor(private http: HttpClient) {}
  onLogin(login: Login): Observable<ResponseData<Token>> {
    return this.http.post<ResponseData<Token>>('url', login);
  }

  onRegister(login: Login): Observable<Response> {
    return this.http.post<Response>('url', login);
  }

  IsLoggedIn(){
    if(this.helper.isTokenExpired(localStorage.getItem('token'))){
      this.logout();
      return false;
    }
    return true;
  }

  logout(){
    localStorage.clear();
  }

  setToken(username: string, token: string){
    localStorage.setItem('username', username as string);
    localStorage.setItem('token', token);
  }
}
