import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BaseService } from 'src/app/core/services/baseService/base.service';
import { User } from 'src/app/data/entity/User';

@Injectable()
export class UserService extends BaseService<User> {
    helper = new JwtHelperService();

    IsLoggedIn() {
        if (this.helper.isTokenExpired(localStorage.getItem('token'))) {
            this.logout();
            return false;
        }

        return true;
    }

    logout() {
        localStorage.clear();
    }

    setToken(user: User, token: string) {
        localStorage.setItem('userEmail', user.email);
        localStorage.setItem('token', token);
    }
}
