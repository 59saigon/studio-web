import { Component } from '@angular/core';
import { User } from 'src/app/data/entity/User';
import { AuthQuery } from 'src/app/data/queries/AuthQuery';
import { UserService } from 'src/app/demo/service/management/user.service';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: [`
        :host ::ng-deep .pi-eye,
        :host ::ng-deep .pi-eye-slash {
            transform:scale(1.6);
            margin-right: 1rem;
            color: var(--primary-color) !important;
        }
    `],
    providers: [UserService]
})
export class LoginComponent {

    valCheck: string[] = ['remember'];

    authQuery: AuthQuery = {} as AuthQuery;

    user: User = {} as User;

    constructor(public layoutService: LayoutService, public userService: UserService) { }

    onLogin(){
        this.userService.onLogin('user', this.authQuery).subscribe({
            next: (response) => {
                this.user = response.result;
                console.table(this.user);
            },
            error: (err) => {
                console.error('Error occurred:', err);
            },
        });
    }
}
