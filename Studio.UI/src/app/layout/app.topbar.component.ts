import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from './service/app.layout.service';
import { UserService } from '../demo/service/management/user.service';
import { User } from '../data/entity/User';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html',
})
export class AppTopBarComponent implements OnInit {
    items!: MenuItem[];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(
        public layoutService: LayoutService,
        public userService: UserService
    ) {}
    ngOnInit(): void {
        this.setModel();
    }
    onOpenConfigModule() {
        this.layoutService.showConfigSidebar();
    }
    openMenu() {
        const menuItem = (
            this.menu.nativeElement.getElementsByClassName(
                'p-menuitem-link'
            ) as HTMLCollectionOf<HTMLElement>
        )[0];

        setTimeout(() => {
            menuItem.focus();
        }, 1);
    }

    setModel() {
        this.items = [
            {
                label: 'Settings',
                icon: 'pi pi-fw pi-cog',
                command: () => {
                    this.onOpenConfigModule();
                },
            },
            {
                label: 'Logout',
                icon: 'pi pi-fw pi-power-off',
                command: () => {
                    this.userService.logout();
                    window.location.reload();
                },
            },
        ];
    }
}
