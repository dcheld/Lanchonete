import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { LancheService } from './lanche.service';
import { LancheModel } from './lanche-model';

@Component({
  selector: 'app-lanche',
  templateUrl: './lanche.component.html',
  styleUrls: ['./lanche.component.scss']
})
export class LancheComponent implements OnInit {

  public lanches$: Observable<LancheModel>;
  public lancheSelecionado: LancheModel;
  constructor(private lancheService: LancheService) { }

  ngOnInit() {
    this.lanches$ = this.lancheService.obterLanches();
  }

  selecionarLanche(lanche: LancheModel) {
    this.lancheSelecionado = lanche;
  }
}
