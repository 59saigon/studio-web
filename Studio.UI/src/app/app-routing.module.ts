import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { AppComponent } from './app.component';
import { AboutComponent } from './features/about/about.component';
import { MomentComponent } from './features/moment/moment.component';
import { ServiceComponent } from './features/service/service.component';
import { ContactComponent } from './features/contact/contact.component';
import { TestComponent } from './features/test/test.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'about',
    component: AboutComponent,
  },
  {
    path: 'moment',
    component: MomentComponent,
  },
  {
    path: 'service',
    component: ServiceComponent,
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    path: 'test',
    component: TestComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
