import { Component, OnInit } from '@angular/core';
import { initFlowbite } from 'flowbite';
import { components } from 'src/app/data/services/common/components';
import { DarkThemeToggleComponent } from 'src/app/data/services/common/dark-theme-toggle.component';
import { NavbarComponent } from 'src/app/data/services/common/navbar.component';
import { SidebarService } from 'src/app/data/services/sidebar';
import { SidebarComponent } from "../../data/services/common/sidebar.component";
import { SidebarItemComponent } from "../../data/services/common/sidebar-item.component";
import { SidebarItemGroupComponent } from "../../data/services/common/sidebar-item-group.component";

@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
    imports: [DarkThemeToggleComponent, NavbarComponent, SidebarComponent, SidebarItemComponent, SidebarItemGroupComponent]
})
export class DashboardComponent implements OnInit {
  title = 'dashboard';
  components = components;
  constructor(readonly sidebarService: SidebarService) {}

  ngOnInit(): void {
    initFlowbite();
  } 

}
