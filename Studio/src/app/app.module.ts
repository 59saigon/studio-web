import { NgModule } from '@angular/core';
import {
    DatePipe,
    HashLocationStrategy,
    LocationStrategy,
    PathLocationStrategy,
} from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { ProductService } from './demo/service/product.service';
import { CustomerService } from './demo/service/customer.service';
import { IconService } from './demo/service/icon.service';
import { NodeService } from './demo/service/node.service';
import { AuthGuard } from './core/guard/auth.guard';
import { UserService } from './demo/service/management/user.service';
import { WeddingService } from './demo/service/management/wedding.service';
import { PhotoService } from './demo/service/management/photo.service';
import { LocationService } from './demo/service/management/location.service';
import { EventXServiceService } from './demo/service/management/eventXService.service';
import { EventXPhotoService } from './demo/service/management/eventXPhoto.service';
import { CountryService } from './demo/service/management/country.service';
import { CityService } from './demo/service/management/city.service';
import { MessageService } from 'primeng/api';
import { ServiceService } from './demo/service/management/service.service';
import { EventService } from './demo/service/management/event.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { CustomeInterceptor } from './core/services/custome/custome.interceptor';

@NgModule({
    declarations: [AppComponent, NotfoundComponent],
    imports: [AppRoutingModule, AppLayoutModule],
    providers: [
        { provide: LocationStrategy, useClass: PathLocationStrategy },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: CustomeInterceptor, // Sử dụng custom interceptor
            multi: true, // Điều này cho phép có nhiều interceptor
        },
        CustomerService,
        IconService,
        NodeService,
        ProductService,

        WeddingService,
        PhotoService,
        LocationService,
        EventXServiceService,
        EventXPhotoService,
        EventService,
        ServiceService,
        CountryService,
        CityService,
        UserService,
        AuthGuard,

        MessageService,
        DatePipe,
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
