import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BaseService } from 'src/app/core/services/baseService/base.service';
import { WeddingResult } from 'src/app/data/results/WeddingResult';
import { WeddingView } from 'src/app/data/views/WeddingView';

@Injectable()
export class WeddingService extends BaseService<WeddingResult, WeddingView> {
    
}
