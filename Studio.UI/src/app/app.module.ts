import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/client/home/home.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { FooterComponent } from './layout/footer/footer.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { CarouselComponent } from './layout/carousel/carousel.component';
import { AboutComponent } from './modules/client/about/about.component';
import { ContactComponent } from './modules/client/contact/contact.component';

import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutComponent } from './modules/client/layout/layout.component';
import { CustomeInterceptor } from './data/services/custome/custome.interceptor';
import { ServiceComponent } from './modules/client/service/service.component';
import { LoginComponent } from './modules/client/login/login.component';
import { RegisterComponent } from './modules/client/register/register.component';
import { WeddingListComponent } from './layout/dashboard/wedding/wedding-list/wedding-list.component';
import { EventComponent } from './modules/client/event/event.component';
import { EventListComponent } from './layout/dashboard/event/event-list/event-list.component';
import { EventCreateComponent } from './layout/dashboard/event/event-create/event-create.component';
import { EventManagementComponent } from './modules/admin/event-management/event-management.component';
import { DashboardManagementComponent } from './modules/admin/dashboard-management/dashboard-management.component';
import { UserManagementComponent } from './modules/admin/user-management/user-management.component';
import { UserListComponent } from './layout/dashboard/user/user-list/user-list.component';
import { UserCreateComponent } from './layout/dashboard/user/user-create/user-create.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    CarouselComponent,
    AboutComponent,
    EventComponent,
    ContactComponent,
    LayoutComponent,
    ServiceComponent,
    LoginComponent,
    RegisterComponent,
    WeddingListComponent,
    EventListComponent,
    EventCreateComponent,
    EventManagementComponent,
    DashboardManagementComponent,
    UserManagementComponent,
    UserListComponent,
    UserCreateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: CustomeInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
