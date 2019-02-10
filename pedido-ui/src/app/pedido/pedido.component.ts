import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { PedidoService } from '../servico/pedido.service';
import { PedidoModel } from '../model/pedido-model';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.scss']
})
export class PedidoComponent implements OnInit {

  public pedido$: Observable<PedidoModel[]>;

  constructor(private pedidoService: PedidoService) { }

  ngOnInit() {
    this.pedido$ = this.pedidoService.obter();
  }

}
