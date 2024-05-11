import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
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
        public constantService: ConstantService,
        private messageService: MessageService
    ) {}

    openMessageSuccess(content: string){
        this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: content,
            life: 3000,
        });
    }
    openMessageError(content: string){
        this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: content,
            life: 3000,
        });
    }
    openMessageWarn(content: string){
        this.messageService.add({
            severity: 'warn',
            summary: 'Warn',
            detail: content,
            life: 3000,
        });
    }

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

    
}
