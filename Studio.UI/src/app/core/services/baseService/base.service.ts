import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Constants } from 'src/app/shared/Constants';
import { ConstantService } from 'src/app/shared/constant.service';

@Injectable({
    providedIn: 'root',
})
//https://localhost:7099/api/wedding/get-wedding-list
export class BaseService<T> {
    constructor(
        public http: HttpClient,
        public constantService: ConstantService
    ) {}

    getListData(entity: string, data: any): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(entity, Constants.GET_LIST),
            data
        );
    }
    getByValueData(
        entity: string,
        data: any,
        valueGetBy: string
    ): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(
                entity,
                Constants.GET_BY,
                valueGetBy
            ),
            data
        );
    }

    postData(entity: string, data: any): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(entity, Constants.CREATE),
            data
        );
    }

    putData(entity: string, data: any): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(entity, Constants.UPDATE),
            data
        );
    }

    deleteData(entity: string, data: any): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(entity, Constants.DELETE),
            data
        );
    }

    onLogin(entity: string, data: any): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(entity, Constants.LOGIN),
            data
        );
    }

    onRegister(entity: string, data: any): Observable<any> {
        return this.http.post(
            this.constantService.receiveInstanceAPI(entity, Constants.REGISTER),
            data
        );
    }

    // constructor(
    //   private http: HttpClient,
    // ) {}

    // getListData(dataQuery: any, ): Observable<any> {
    //   return this.http.post<MessageResults<T>>(
    //     '/api/wedding/get-wedding-list',
    //     dataQuery
    //   );
    // }
    // getByValueData(dataQuery: any): Observable<any> {
    //   return this.http.post<MessageResults<T>>(
    //     'https://localhost:7099/api/wedding/get-by-id',
    //     dataQuery
    //   );
    // }

    // postData(dataCommand: any): Observable<any> {
    //   return this.http.post<MessageView<T>>(
    //     'https://localhost:7099/api/wedding/create-wedding',
    //     dataCommand
    //   );
    // }

    // putData(dataCommand: any): Observable<any> {
    //   return this.http.post<MessageView<T>>(
    //     'https://localhost:7099/api/wedding/update-wedding',
    //     dataCommand
    //   );
    // }

    // deleteData(dataCommand: any): Observable<any> {
    //   return this.http.post<MessageView<T>>(
    //     'https://localhost:7099/api/wedding/delete-wedding',
    //     dataCommand
    //   );
    // }
}
