import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
let ContactsService = class ContactsService {
    constructor(http) {
        this.http = http;
        this.myAppUrl = 'http://localhost:61236/';
        this.myApiUrl = 'api/ContactsApi';
        this.updateForm = new BehaviorSubject({});
    }
    saveContact(contact) {
        return this.http.post(this.myAppUrl + this.myApiUrl, contact);
    }
    getContacts() {
        this.http.get(this.myAppUrl + this.myApiUrl).toPromise()
            .then(data => {
            this.list = data;
        });
    }
    deleteContact(id) {
        return this.http.delete(this.myAppUrl + this.myApiUrl + "/" + id);
    }
    updateContact(id, contact) {
        return this.http.put(this.myAppUrl + this.myApiUrl + "/" + id, contact);
    }
    update(contact) {
        this.updateForm.next(contact);
    }
    getContact() {
        return this.updateForm.asObservable();
    }
};
ContactsService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], ContactsService);
export { ContactsService };
//# sourceMappingURL=contacts.service.js.map