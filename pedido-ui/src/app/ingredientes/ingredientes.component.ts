import { Component, OnInit, Input } from '@angular/core';

import { LancheModel } from './../lanche/lanche-model';

@Component({
  selector: 'app-ingredientes',
  templateUrl: './ingredientes.component.html',
  styleUrls: ['./ingredientes.component.scss']
})
export class IngredientesComponent implements OnInit {

  @Input()
  public lanche = new LancheModel();

  constructor() { }

  ngOnInit() {
  }

  lancheSelecioando() {
    return !!this.lanche;
  }

  onSubmit() {

  }
}
