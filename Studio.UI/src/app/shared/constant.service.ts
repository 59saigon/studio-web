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

  receiveInstanceAPI(
    entity: string,
    rest: string,
    valueGetBy?: string
  ): string {
    switch (rest) {
      case Constants.CREATE:
        return this.getInstanceAPI(entity, rest);
      case Constants.UPDATE:
        return this.getInstanceAPI(entity, rest);
      case Constants.DELETE:
        return this.getInstanceAPI(entity, rest);
      case Constants.GET_LIST:
        return this.getInstanceAPIList(entity, rest);
      case Constants.GET_BY:
        return this.getInstanceAPIBy(entity, rest, valueGetBy);
      default:
        return 'Not found rest.';
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
}