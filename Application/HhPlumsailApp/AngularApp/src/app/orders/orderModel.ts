export interface OrderModel {
    id: number;
    date: Date;
    customer: string;
    status: object;
    prepaid: boolean;
    summ: number;
    description: string;
}

export enum OrderStatus {
    Created = 0,
    InProcess,
    Closed
}