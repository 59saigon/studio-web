import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/data/entity/User';
import { AuthQuery } from 'src/app/data/queries/AuthQuery';
import { UserService } from 'src/app/demo/service/management/user.service';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
})
export class LoginComponent {

    valCheck: string[] = ['remember'];

    authQuery: AuthQuery = {} as AuthQuery;

    user: User = {} as User;

    token: string = "";

    constructor(public layoutService: LayoutService, public userService: UserService, private router: Router) { }

    onLogin(){
        console.log(this.authQuery);
        this.userService.onLogin('user', this.authQuery).subscribe({
            next: (response) => {
                this.user = response.result;
                this.token = response.token;
                this.userService.setToken(this.user, this.token);
                this.router.navigateByUrl('/');
                console.table(response.result);
            },
            error: (err) => {
                console.error('Error occurred:', err);
            },
        });
    }
}
