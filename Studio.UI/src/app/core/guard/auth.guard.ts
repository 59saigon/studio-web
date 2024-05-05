import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    CanActivate,
    CanActivateFn,
    Router,
    RouterStateSnapshot,
} from '@angular/router';
import { UserService } from 'src/app/demo/service/management/user.service';

@Injectable({
    providedIn: 'root',
})
export class AuthGuard implements CanActivate {
    constructor(private userService: UserService, private router: Router) {
        console.log('AuthGuard');
    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): boolean {
        if (this.userService.IsLoggedIn()) {
            console.log('true');
            return true;
        } else {
            this.router.navigateByUrl('/auth/login');
            console.log('false');
            return false;
        }
    }
}
