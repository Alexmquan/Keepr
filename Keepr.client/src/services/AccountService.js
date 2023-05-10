import { AppState } from '../AppState'
import { Account, Profile } from '../models/Account.js'
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(accountData) {
    const res = await api.put('/account', accountData)
    AppState.account = new Account(res.data)
  }

  async getMyVaultKeeps() {
    const res = await api.get('account/vaultKeep')
    AppState.vaultKeeps = res.data.map(vk => new VaultKeep(vk))
  }



}

export const accountService = new AccountService()
