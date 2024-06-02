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
        const currentUrl = state.url; // Đường dẫn hiện tại

        if (this.userService.IsLoggedIn()) {
            if (currentUrl === '/auth/login') {
                // Nếu người dùng đã đăng nhập và đang cố gắng truy cập trang đăng nhập, chuyển hướng họ
                this.router.navigate(['/']); // Chuyển hướng đến trang chính hoặc trang khác
                return false; // Ngăn kích hoạt tuyến đường
            }
            return true; // Cho phép truy cập nếu đã đăng nhập
        } else {
            if (currentUrl === '/auth/login') {
                // Nếu chưa đăng nhập và cố gắng truy cập trang đăng nhập, cho phép
                return true; // Cho phép truy cập
            }
            // Nếu chưa đăng nhập và cố gắng truy cập các trang khác, chuyển hướng đến trang đăng nhập
            this.router.navigateByUrl('/auth/login'); // Chuyển hướng đến trang đăng nhập
            return false; // Ngăn kích hoạt tuyến đường
        }
    }
}
