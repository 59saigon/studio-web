import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/client/home/home.component';
import { AppComponent } from './app.component';
import { AboutComponent } from './modules/client/about/about.component';
import { ContactComponent } from './modules/client/contact/contact.component';
import { ServiceComponent } from './modules/client/service/service.component';
import { LoginComponent } from './modules/client/login/login.component';
import { RegisterComponent } from './modules/client/register/register.component';
import { LayoutComponent } from './modules/client/layout/layout.component';
import { AuthGuard } from './core/guard/auth.guard';
import { DashboardComponent } from './modules/admin/dashboard/dashboard.component';
import { EventComponent } from './modules/client/event/event.component';
import { WeddingListComponent } from './layout/dashboard/wedding/wedding-list/wedding-list.component';
import { WeddingManagementComponent } from './modules/admin/wedding-management/wedding-management.component';
import { EventManagementComponent } from './modules/admin/event-management/event-management.component';
import { DashboardManagementComponent } from './modules/admin/dashboard-management/dashboard-management.component';
import { UserManagementComponent } from './modules/admin/user-management/user-management.component';
import { WeddingCreateComponent } from './layout/dashboard/wedding/wedding-create/wedding-create.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  // {
  //   path: 'wedding-create',
  //   component: WeddingCreateComponent,
  //   //canActivate: [AuthGuard]
  // },
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      {
        path: 'dashboard-management',
        component: DashboardManagementComponent,
        //canActivate: [AuthGuard]
      },
      {
        path: 'wedding-management',
        component: WeddingManagementComponent,
         children:[
          {
            path: 'wedding-list',
            component: WeddingListComponent,
            //canActivate: [AuthGuard]
          },
          {
            path: 'wedding-create',
            component: WeddingCreateComponent,
            //canActivate: [AuthGuard]
          },
         ]
        //canActivate: [AuthGuard]
      },
      {
        path: 'event-management',
        component: EventManagementComponent,
        //canActivate: [AuthGuard]
      },
      {
        path: 'user-management',
        component: UserManagementComponent,
        //canActivate: [AuthGuard]
      },
    ],
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'home',
        component: HomeComponent,
        //canActivate: [AuthGuard]
      },
      {
        path: 'about',
        component: AboutComponent,
        //canActivate: [AuthGuard]
      },
      {
        path: 'event',
        component: EventComponent,
        //canActivate: [AuthGuard]
      },
      {
        path: 'service',
        component: ServiceComponent,
        //canActivate: [AuthGuard]
      },
      {
        path: 'contact',
        component: ContactComponent,
        //canActivate: [AuthGuard]
      },
    ],
  },
  {
    path: '**',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
