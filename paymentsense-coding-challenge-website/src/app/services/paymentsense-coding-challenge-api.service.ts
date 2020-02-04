import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pagination } from './pagination';
import { CountryResponseModel } from './country-response.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentsenseCodingChallengeApiService {
  constructor(private httpClient: HttpClient) {}

  public getHealth(): Observable<string> {
    return this.httpClient.get('https://localhost:5001/health', {
      responseType: 'text'
    });
  }

  public getCountries(
    pagination: Pagination = new Pagination()
  ): Observable<CountryResponseModel> {
    const params = new HttpParams()
      .set('page', pagination.page.toString())
      .set('pageSize', pagination.pageSize.toString());
    return this.httpClient.get<CountryResponseModel>(
      'https://localhost:5001/api/Countries',
      {
        params
      }
    );
  }
  public getCountryDetail(alpha2Code) {
    return this.httpClient.get<object>(
      `https://localhost:5001/api/Countries/${alpha2Code}`
    );
  }
}
