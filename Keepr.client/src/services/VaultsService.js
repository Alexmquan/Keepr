import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class VaultsService {
  async createVault(vaultData) {
    const res = await api.post("api/vaults", vaultData)
    logger.log('[New Vault]', res.data)
    AppState.vaults.push(new Vault(res.data))
  }

  async setActiveVault(vaultId) {

    const activeVault = AppState.vaults.find(v => v.id == vaultId)
    AppState.activeVault = activeVault
  }
}

export const vaultsService = new VaultsService()