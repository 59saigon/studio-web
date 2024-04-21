import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseCommand, CreateCommand, DeleteCommand, UpdateCommand } from 'src/app/data/commands/BaseCommand';
import { WeddingCreateCommand } from 'src/app/data/commands/weddings/WeddingCommand';
import { GetAllQuery, GetByIdQuery } from 'src/app/data/queries/BaseQuery';
import { Constants } from 'src/app/shared/utilities/constants/Constants';
import { ConstantService } from 'src/app/shared/utilities/constants/constant.service';

@Injectable({
  providedIn: 'root',
})
export class BaseService{
  constructor(
    private http: HttpClient,
    private constantService: ConstantService
  ) {}

  getListData(entity: string, dataQuery: GetAllQuery): Observable<any> {
    return this.http.post(
      this.constantService.receiveInstanceAPI(entity, Constants.GET_LIST),
      dataQuery
    );
  }
  getByValueData(entity: string, dataQuery: GetByIdQuery, valueGetBy: string): Observable<any> {
    return this.http.post(
      this.constantService.receiveInstanceAPI(entity, Constants.GET_BY, valueGetBy),
      dataQuery
    );
  }

  postData(entity: string, dataCommand: any): Observable<any> {
    return this.http.post(
      this.constantService.receiveInstanceAPI(entity, Constants.CREATE),
      dataCommand
    );
  }

  putData(entity: string, dataCommand: UpdateCommand): Observable<any> {
    return this.http.post(
      this.constantService.receiveInstanceAPI(entity, Constants.UPDATE),
      dataCommand
    );
  }

  deleteData(entity: string, dataCommand: DeleteCommand): Observable<any> {
    return this.http.post(
      this.constantService.receiveInstanceAPI(entity, Constants.DELETE),
      dataCommand
    );
  }
}
