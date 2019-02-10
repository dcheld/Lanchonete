import { LancheModel } from './lanche-model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LancheService {

  constructor(private http: HttpClient) { }

  obterLanches(): Observable<LancheModel> {
    return this.http.get<LancheModel>('http://localhost:5000/api/lanche');
  }
}
