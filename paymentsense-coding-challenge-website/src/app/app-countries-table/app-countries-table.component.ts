import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { MatTableDataSource} from '@angular/material/table';
import { Country } from '../services/country';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { PaymentsenseCodingChallengeApiService } from '../services';
import { Pagination } from '../services/pagination';
import { trigger, state, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-countries-table',
  templateUrl: './app-countries-table.component.html',
  styleUrls: ['./app-countries-table.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class AppCountriesTableComponent implements OnInit {

  public constructor(private _service: PaymentsenseCodingChallengeApiService) {
  }

  @Output() emitter = new EventEmitter();
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  displayedColumns: string[] = ['name', 'flag'];
  dataSource:MatTableDataSource<Country>;
  pageIndex = 1;
  pageSize = 5;
  length = 0;
  expandedElement: Country;

  ngOnInit() {
    this._service.getCountries().subscribe(r => {
      this.dataSource = new MatTableDataSource<Country>(r.data);
      this.length = r.total;
      this.dataSource.paginator = this.paginator;
    });
  }

  getCountries(event?: PageEvent) {
    const pagination = new Pagination();
    pagination.page = event.pageIndex;
    pagination.pageSize = event.pageSize;

    this._service.getCountries(pagination).subscribe(r => {
      this.dataSource = new MatTableDataSource<Country>(r.data);
      this.length = r.total;
    });
    return event;
  }

  getRecord(row: Country) {
    this._service.getCountryDetail(row.Alpha2Code).subscribe(result => {
      alert(JSON.stringify(result));
      this.emitter.emit(result);
    });
  }
}
