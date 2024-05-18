import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/baseService/base.service';
import { Country } from 'src/app/data/entity/Country';

@Injectable()
export class CountryService extends BaseService<Country> {
    
}
