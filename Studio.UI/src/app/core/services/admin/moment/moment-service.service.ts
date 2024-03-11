import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Moment } from 'src/app/models/add-moment.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MomentServiceService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) {}

  getMoments(): Observable<Moment[]> {
    return this.http.get<Moment[]>(this.baseApiUrl + '/api/moment');
  }

  createMoment(addMomentRequest: Moment): Observable<Moment> {
    return this.http.post<Moment>(
      this.baseApiUrl + '/api/moment',
      addMomentRequest
    );
  }
}
