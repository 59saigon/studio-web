export interface ResponseData<T>{
    isSuccess: boolean,
    message: string,
    responseData: T,
}

export interface ResponseDatas<T>{
    isSuccess: boolean,
    message: string,
    responseData: T[],
}

export interface Response{
    isSuccess: boolean,
    message: string,
}