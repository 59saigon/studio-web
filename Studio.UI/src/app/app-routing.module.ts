import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { AppComponent } from './app.component';
import { AboutComponent } from './features/about/about.component';
import { MomentComponent } from './features/moment/moment.component';
import { ContactComponent } from './features/contact/contact.component';
import { AddMomentComponent } from './features/add-moment/add-moment.component';
import { ServiceComponent } from './features/service/service.component';
import { LoginComponent } from './features/login/login.component';
import { RegisterComponent } from './features/register/register.component';
import { LayoutComponent } from './features/layout/layout.component';
import { AuthGuard } from './guard/auth.guard';

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
