import { TestBed } from '@angular/core/testing';
import { ContactsService } from './contacts.service';
describe('ContactsService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(ContactsService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=contacts.service.spec.js.map