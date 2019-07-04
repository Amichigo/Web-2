import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { LessonInput, LessonServiceProxy } from '@shared/service-proxies/service-proxies';
import { HttpClient, HttpRequest, HttpParams } from '@angular/common/http';


@Component({
    selector: 'createOrEditGVLessonModal',
    templateUrl: './create-or-edit-grammar-vocab-lesson.component.html'
})
export class CreateOrEditGVLessonModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('lessonCombobox') lessonCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    private originPath: string = "E:\\VisualStudio_Projects\\aspzero\\angular\\src\\assets\\";
    lessonlink: string = "";
    lessonIntroImage: string = "";
    saving = false;

    lesson: LessonInput = new LessonInput();

    constructor(
        injector: Injector,
        private _lessonService: LessonServiceProxy,
        private http: HttpClient
    ) {
        super(injector);
    }

    show(lessonId?: number | null | undefined): void {
        this.saving = false;


        this._lessonService.getLessonForEdit(lessonId).subscribe(result => {
            this.lesson = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.lesson;
        this.saving = true;
        input.introImage = this.lessonIntroImage;
        input.link = this.lessonlink;
        this._lessonService.createOrEditLesson(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    upload(files,isContent:boolean) {
        if (files.length === 0)
            return;
        if (this.lesson.catName == null)
            return;

        const formData = new FormData();

        for (let file of files) {
            formData.append(file.name, file);
            if (isContent === false) this.lessonIntroImage = "assets/" + this.lesson.catName + '/' + file.name;
            else this.lessonlink = "assets/" + this.lesson.catName + '/' + file.name;
        }
        let desPath = this.originPath + this.lesson.catName + "\\";
        let params = new HttpParams().set("desPath", desPath)
        const uploadReq = new HttpRequest('POST', `http://Localhost:5000/api/upload`, formData, {
            reportProgress: true,
            params: params
        });
        if (isContent === false) this.lessonIntroImage = "assets" + this.lesson.catName;
        this.http.request(uploadReq).subscribe(event => console.log(event));
    }
}
