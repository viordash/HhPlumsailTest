import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { AuthTokenModel } from '../authentification/authTokenModel';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  constructor() { }

  public acceptToken(authToken: AuthTokenModel): void {
    console.log(authToken);
  }

  public getToken(): AuthTokenModel {
    const token: AuthTokenModel = {
      access_token: "ZrxXtAYdMny6sldxyziebJdt5X-Fyp38ksz9n5We-ZH5pV2VapeU1HSFg0WyEuBtVPboiqeroed4LuxrpcPco0Ed1aO5vZHKI4eyAhlbC7ETIiAS02a0hwdUmqI_mLzrDafEOGBzXC7qge5NRjo5TBAGDc-0Mle_NED34LMvGmV-fEEcfG392mgBPspnpCGXxPAfbg2nxXI7OryPCWFRwWpt7W8uROkuJG24-ojFGwKNBB45E27g_UTRqC7sC7RD2ikvqSSnN3pJaKwVznjS4fnM-AzEK3ikGADLyhEjfcpGPhD9Hs8NzSiX9fx72h3E2T87Xkmo6_hhwTxs3tbSIA",
      token_type: "bearer",
      expires_in: 86399,
      userName: "viordash",
    }
    return token;
  }
}
