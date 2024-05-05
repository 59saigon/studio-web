import { Injectable } from '@angular/core';
import { Constants } from './Constants';

@Injectable({
    providedIn: 'root',
})
export class ConstantService {
    constructor() {}

    //https://localhost:7099/api/wedding/get-wedding-list

    private setInstanceAPI(entity: string, rest: string): string {
        var apiLink = `${Constants.BASE_URL}/api/${entity}/${rest}-${entity}`;
        return apiLink;
    }

    private setInstanceByAPI(entity: string, rest: string): string {
        var apiLink = `${Constants.BASE_URL}/api/${entity}/${rest}`;
        return apiLink;
    }

    private setInstanceNoUnderlineAPI(entity: string, rest: string): string {
        var apiLink = `${Constants.BASE_URL}/api/${entity}/${rest}`;
        return apiLink;
    }



    receiveInstanceAPI(
        entity: string,
        rest: string,
        valueGetBy?: string
    ): string {
        switch (rest) {
            case Constants.GET_LIST:
                return this.getInstanceAPIList(entity, rest);
                break;
            case Constants.GET_BY:
                return this.getInstanceAPIBy(entity, rest, valueGetBy);
                break;
            case Constants.LOGIN || Constants.REGISTER:
                return this.getInstanceAPINoUnderline(entity, rest);
                break;
            default:
                return this.getInstanceAPI(entity, rest);
                break;
        }
    }

    private getInstanceAPIList(entity: string, rest: string): string {
        return `${this.setInstanceAPI(entity, rest)}-list`;
    }

    private getInstanceAPIBy(
        entity: string,
        rest: string,
        valueGetBy?: string
    ): string {
        return `${this.setInstanceByAPI(entity, rest)}-${valueGetBy}`;
    }

    private getInstanceAPI(entity: string, rest: string): string {
        return this.setInstanceAPI(entity, rest);
    }

    private getInstanceAPINoUnderline(entity: string, rest: string): string {
        return this.setInstanceNoUnderlineAPI(entity, rest);
    }
}
