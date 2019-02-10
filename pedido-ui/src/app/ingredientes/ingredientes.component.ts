import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

import { PedidoService } from '../servico/pedido.service';
import { LancheModel } from '../model/lanche-model';

@Component({
  selector: 'app-ingredientes',
  templateUrl: './ingredientes.component.html',
  styleUrls: ['./ingredientes.component.scss']
})
export class IngredientesComponent implements OnInit {

  @Input() public lanche: LancheModel = new LancheModel();

  @Output() public cancelar: EventEmitter<any> = new EventEmitter();

  constructor(private pedidoService: PedidoService,
    private router: Router) { }

  ngOnInit() {
  }

  lancheSelecioando() {
    return !!this.lanche;
  }

  onSubmit() {
    this.pedidoService.inserir(this.lanche)
      .subscribe(() => this.router.navigate(['/pedido']));
  }

  onCancelar() {
    this.cancelar.emit(null);
  }
}
