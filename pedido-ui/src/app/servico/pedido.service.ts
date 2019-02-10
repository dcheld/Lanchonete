import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { LancheModel } from './../model/lanche-model';
import { PedidoModel } from '../model/pedido-model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  constructor(private http: HttpClient) { }

  inserir(lanche: LancheModel) {
    return this.http.post<LancheModel>('http://localhost:5000/api/pedido', lanche, httpOptions);
  }

  obter() {
    return this.http.get<PedidoModel[]>('http://localhost:5000/api/pedido', httpOptions);
  }
}
