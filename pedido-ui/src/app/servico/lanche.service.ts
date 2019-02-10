import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LancheModel } from '../model/lanche-model';
import { LancheItemModel } from '../model/lanche-item-model';

@Injectable({
  providedIn: 'root'
})
export class LancheService {

  constructor(private http: HttpClient) { }

  obterLanches(): Observable<LancheModel> {
    return this.http.get<LancheModel>('http://localhost:5000/api/lanche');
  }

  obterTodosItensLanche(): Observable<LancheItemModel[]> {
    return this.http.get<LancheItemModel[]>('http://localhost:5000/api/lanche/itens');
  }
}
