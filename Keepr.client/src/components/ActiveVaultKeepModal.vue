<template>
  <div class="row modal-size" v-if="activeKeep">
    <div class="col-md-6 picture-size no-mobile-display"
      :style="{ backgroundImage: `url(${activeKeep.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }">
      <!-- <img :src="activeKeep.img" alt=""> -->
    </div>
    <div class="col-md-6 no-pad mobile-display">
      <img class=" picture-size" :src="activeKeep.img" alt="">

    </div>
    <div class="col-md-6">
      <div class="d-flex justify-content-between flex-column  content-size">
        <div class="d-flex justify-content-center mt-3 row">
          <div class="col-4"></div>
          <div class="col-4 d-flex justify-content-center align-items-center">
            <h4>
              <i class="mdi mdi-eye" title="views count"></i>
              {{ activeKeep.views }}
            </h4>
            <h4 class="ms-3">
              <i class="mdi mdi-alpha-k-box-outline" title="kept count"></i>
              {{ activeKeep.kept }}
            </h4>

          </div>
          <div class="col-4 d-flex justify-content-end align-items-center"><i v-if="account.id == activeKeep.creatorId"
              class="mdi mdi-delete-outline me-4 trashcan selectable fs-4" title="Delete Keep"
              @click="deleteKeep(activeKeep.id)" data-bs-dismiss="modal"></i>
          </div>
        </div>
        <div class="px-3">
          <h3 class="text-center">{{ activeKeep.name }}</h3>
          <p>{{ activeKeep.description }}</p>
        </div>
        <div class="d-flex justify-content-between align-items-center px-3 pb-3 ">
          <div class="ms-4" v-if="account.id == activeKeep.creatorId">
            <h5 class="selectable rounded px-1" @click="removeVaultKeep()" data-bs-dismiss="modal"><i
                class="mdi mdi-cancel" title="remove keep keep from vault"></i> Remove</h5>
          </div>


          <div class="d-flex align-items-center">
            <router-link :to="{ name: 'Profile', params: { profileId: activeKeep.creator.id } }">
              <img class="creator-image" :src="activeKeep.creator.picture" alt="creators image"
                :title="activeKeep.creator.name" data-bs-dismiss="modal">
            </router-link>
            <h6 class="ps-2"> {{ activeKeep.creator.name }}</h6>
          </div>

        </div>
      </div>
    </div>
  </div>

  <SmallModal id="createVault">
    <template #header>
      <div>Add your vault</div>
    </template>
    <template #body>
      <CreateVaultForm />
    </template>
  </SmallModal>
</template>


<script>
import { computed, onMounted, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { keepsService } from "../services/KeepsService.js";
import { logger } from "../utils/Logger.js";
import AddVaultKeep from "./AddVaultKeep.vue";
import { profilesService } from "../services/ProfilesService.js";
import { accountService } from "../services/AccountService.js";
import SmallModal from "./SmallModal.vue";
import CreateVaultForm from "./CreateVaultForm.vue";
import { vaultKeepService } from "../services/VaultKeepService.js";

export default {
  setup() {

    async function getVaultsByAccountId() {
      try {
        const accountId = AppState.account.id
        await profilesService.getVaultsByAccountId(accountId);
      }
      catch (error) {
        logger.log(error.message);
        Pop.error(error.message);
      }
    }


    watchEffect(() => {
      if (AppState.account) {
        getVaultsByAccountId()
      }
    })
    return {
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      activeVaultKeep: computed(() => AppState.vaultKeeps.find(vk =>
        (vk.keepId == AppState.activeKeep.id && vk.vaultId == AppState.activeVault.id)
      )),
      async deleteKeep(keepId) {
        try {
          logger.log("test");
          if (await Pop.confirm("Are you sure you want to delete this Keep?")) {
            await keepsService.deleteKeep(keepId);
          }
        }
        catch (error) {
          Pop.error(error);
        }
      },
      async removeVaultKeep() {
        try {
          logger.log("[Active Vault Keep]", this.activeVaultKeep)
          const vaultKeepId = this.activeVaultKeep.id
          if (await Pop.confirm("Are you sure you want to remove this keep from this vault?")) {
            await vaultKeepService.removeVaultKeep(vaultKeepId)
          }
        } catch (error) {
          Pop.error(error)
        }
      }
    };
  },
  components: { AddVaultKeep, SmallModal, CreateVaultForm }
}
</script>


<style lang="scss" scoped>
.trashcan {
  color: rgb(237, 94, 94);

}

.green {
  color: rgb(16, 112, 16);
}


@media screen and (min-width: 768px) {
  .modal-size {
    height: 60vh;
    // width: 60vw;
  }

  .picture-size {

    border-bottom-left-radius: 8px;
    border-top-left-radius: 8px;
  }

  .content-size {
    height: 100%;
  }

  .creator-image {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
  }

  .mobile-display {
    display: none;
  }
}

@media screen and (max-width: 768px) {
  // .modal-size {
  //   height: 95vh;
  //   width: 100vw;
  // }

  .picture-size {
    object-fit: cover;
    object-position: center;
    height: 45vh;
    width: 100%;
    border-top-right-radius: 8px;
    border-top-left-radius: 8px;
  }

  .content-size {
    min-height: 45vh;
  }

  .creator-image {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
  }

  .no-pad {
    padding-top: 0 !important;
  }

  .no-mobile-display {
    display: none;
  }
}
</style>