import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "src/app/core/services/baseService/base.service";
import { User } from "src/app/data/entity/User";
import { Constants } from "src/app/shared/Constants";

@Injectable()
export class UserService extends BaseService<User> {
    
}