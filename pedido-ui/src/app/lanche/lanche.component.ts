import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { LancheService } from '../servico/lanche.service';
import { LancheModel } from '../model/lanche-model';
import { LancheItemModel } from '../model/lanche-item-model';

@Component({
  selector: 'app-lanche',
  templateUrl: './lanche.component.html',
  styleUrls: ['./lanche.component.scss']
})
export class LancheComponent implements OnInit {

  public lanches$: Observable<LancheModel>;
  public lancheSelecionado: LancheModel;

  private lancheItens: LancheItemModel[];
  constructor(private lancheService: LancheService) { }

  ngOnInit() {
    this.lanches$ = this.lancheService.obterLanches();
    this.lancheService.obterTodosItensLanche()
      .subscribe(lancheItens => this.lancheItens = lancheItens);
  }

  selecionarLanche(lanche: LancheModel) {
    this.lancheSelecionado = lanche;
  }

  novoLanche() {
    this.lancheSelecionado = new LancheModel();
    this.lancheSelecionado.id = 0;
    this.lancheSelecionado.nome = 'Meu lanche';
    this.lancheSelecionado.lancheItens = this.lancheItens;
  }

  onCancelar() {
    this.lancheSelecionado = null;
  }
}
