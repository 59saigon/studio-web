import { Component, ElementRef, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from './service/app.layout.service';
import { UserService } from '../demo/service/management/user.service';
import { User } from '../data/entity/User';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html',
})
export class AppTopBarComponent {
    items!: MenuItem[];
    m: any[] = [];
    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(
        public layoutService: LayoutService,
        public userService: UserService
    ) {
        console.log(userService.getUserDetails().avatar);
        this.setModel();
    }
    onOpenConfigModule() {
        this.layoutService.showConfigSidebar();
    }

    setModel() {
        this.m = [
            {
                label: 'Settings',
                icon: 'pi pi-fw pi-cog',
                //click: this.onOpenConfigModule()                
            },
            {
                label: 'Logout',
                icon: 'pi pi-fw pi-power-off',
                // click: () => {
                //     this.userService.logout();
                //     window.location.reload();
                // },
            },
            
        ];
    }
}
