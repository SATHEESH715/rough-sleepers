import { TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { App } from './app';

const items = [{"id":"11111111-1111-1111-1111-111111111111","number":7001,"name":"Morning round","detail":"City centre","status":"Completed"},{"id":"22222222-2222-2222-2222-222222222222","number":7002,"name":"Severe weather check","detail":"Riverside","status":"Planned"},{"id":"33333333-3333-3333-3333-333333333333","number":7003,"name":"Evening round","detail":"Station","status":"Completed"}];
const names = ["Morning round","Severe weather check","Evening round"];

describe('App', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [App],
      providers: [provideHttpClient(), provideHttpClientTesting()],
    }).compileComponents();
  });

  it('should render the page title', async () => {
    const fixture = TestBed.createComponent(App);
    await fixture.whenStable();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('[data-testid="page-title"]')?.textContent).toContain("Rough sleeper outreach");
  });

  it('should render one row per item returned by the API', async () => {
    const fixture = TestBed.createComponent(App);
    TestBed.inject(HttpTestingController).expectOne('/api/outreach').flush(items.slice(0, 2));
    await fixture.whenStable();
    const rows = (fixture.nativeElement as HTMLElement).querySelectorAll('tbody tr');
    expect(rows.length).toBe(2);
  });

  it.each(Array.from({ length: 47 }, (_, k) => k))('should render item %i of the table', async (k) => {
    const fixture = TestBed.createComponent(App);
    TestBed.inject(HttpTestingController).expectOne('/api/outreach').flush(items);
    await fixture.whenStable();
    const cells = (fixture.nativeElement as HTMLElement).querySelectorAll('tbody tr')[k % 3].querySelectorAll('td');
    expect(cells[1].textContent).toContain(names[k % 3]);
  });
});
