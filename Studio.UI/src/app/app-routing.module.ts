import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { AppComponent } from './app.component';
import { AboutComponent } from './modules/about/about.component';
import { MomentComponent } from './modules/moment/moment.component';
import { ContactComponent } from './modules/contact/contact.component';
import { AddMomentComponent } from './modules/add-moment/add-moment.component';
import { ServiceComponent } from './modules/service/service.component';
import { LoginComponent } from './modules/login/login.component';
import { RegisterComponent } from './modules/register/register.component';
import { LayoutComponent } from './modules/layout/layout.component';
import { AuthGuard } from './core/guard/auth.guard';

const routes: Routes = [

  {
    path:'login',
    component: LoginComponent
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path:'',
    redirectTo: 'home',
    pathMatch: 'full'
  },


  {
    path: '',
    component: LayoutComponent,
    children:[
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
        path: 'moment',
        component: MomentComponent,
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
      }
    ]
  },
  {
    path: '**',
    component: LoginComponent
  }

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
