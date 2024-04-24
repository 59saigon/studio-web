import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseCommand, CreateCommand, DeleteCommand, UpdateCommand } from 'src/app/data/commands/BaseCommand';
import { GetAllQuery } from 'src/app/data/queries/BaseQuery';
import { MessageResults } from 'src/app/data/results/MessageResult';
import { MessageView } from 'src/app/data/views/MessageView';

@Injectable({
  providedIn: 'root',
})
  //https://localhost:7099/api/wedding/get-wedding-list

export class BaseService<TResult, TView>{
  constructor(
    private http: HttpClient,
  ) {}

  getListData(dataQuery: any): Observable<any> {
    return this.http.post<MessageResults<TResult>>(
      'https://localhost:7099/api/wedding/get-wedding-list',
      dataQuery
    );
  }
  getByValueData(dataQuery: any): Observable<any> {
    return this.http.post<MessageResults<TResult>>(
      'https://localhost:7099/api/wedding/get-by-id',
      dataQuery
    );
  }

  postData(dataCommand: any): Observable<any> {
    return this.http.post<MessageView<TView>>(
      'https://localhost:7099/api/wedding/create-wedding',
      dataCommand
    );
  }

  putData(dataCommand: any): Observable<any> {
    return this.http.post<MessageView<TView>>(
      'https://localhost:7099/api/wedding/update-wedding',
      dataCommand
    );
  }

  deleteData(dataCommand: any): Observable<any> {
    return this.http.post<MessageView<TView>>(
      'https://localhost:7099/api/wedding/delete-wedding',
      dataCommand
    );
  }
}
