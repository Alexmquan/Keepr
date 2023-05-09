<template>
  <div class="container-fluid" v-if="activeVault">
    <!-- SECTION top -->
    <section class="header-cont">
      <div
        class="cover-img mt-4 d-flex justify-content-end align-items-center text-light flex-column text-shadow text-center"
        :style="{ backgroundImage: `url(${activeVault.img})`, backgroundPosition: 'center', backgroundSize: 'cover' }">
        <div class="mb-4">
          <h1 class="mb-2">{{ activeVault.name }}</h1>
          <h6>by {{ activeVault.creator.name }}</h6>

        </div>
      </div>
      <div class="d-flex justify-content-end" v-if="account.id == activeVault.creator.id">
        <i class="mdi mdi-dots-horizontal selectable me-2 dropdown-toggle fs-3" data-bs-toggle="dropdown"
          type="button"></i>

        <ul class="dropdown-menu drop-style">
          <li><a class="dropdown-item" href="#" data-bs-toggle="modal" data-bs-target="#editVault">Edit Vault</a></li>
          <div class="dropdown-border"></div>
          <li><a class="dropdown-item" href="#" @click="deleteVault(activeVault.id)">Delete Vault <i
                class="mdi mdi-delete-outline"></i></a></li>
        </ul>
      </div>
      <div class="d-flex justify-content-center">
        <h5 class="count-style elevation-1">{{ vaultKeeps.length }} Keeps</h5>
      </div>
    </section>
    <!-- SECTION Vault Keeps -->
    <div class="mt-4">
      <h2 class="width-100 mb-3">Keeps</h2>
      <div class="vault-cont">
        <div class="card card-style mb-3 rounded " v-for="vk in vaultKeeps" :id="vk.id">
          <VaultKeepCard :vaultKeep="vk" />
        </div>
      </div>
    </div>
    <section>


    </section>
  </div>
  <SmallModal id="editVault">
    <template #header>
      <div>Edit your Vault</div>
    </template>
    <template #body>
      <EditVaultForm />
    </template>
  </SmallModal>
  <LargeModal id="keepModal">
    <template #body>
      <ActiveKeepCard />
    </template>
  </LargeModal>
</template>


<script>
import { useRoute, useRouter } from "vue-router";
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";
import { computed, onMounted } from "vue";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import KeepCard from "../components/KeepCard.vue";
import ActiveKeepCard from "../components/ActiveKeepCard.vue";
import LargeModal from "../components/LargeModal.vue";
import VaultKeepCard from "../components/VaultKeepCard.vue";
import SmallModal from "../components/SmallModal.vue";

export default {
  setup() {
    const router = useRouter()
    const route = useRoute();
    async function getVaultById() {
      try {
        const vaultId = route.params.vaultId;
        logger.log(vaultId);
        await vaultsService.getVaultById(vaultId);
      }
      catch (error) {
        let errorMessage = error.response.data;
        if (errorMessage == 'This Vault is locked doooown') {
          logger.error(error);
          Pop.toast(errorMessage, "error")
          router.push({ name: "Home" })
        }
        else {
          Pop.error(error);
        }

      }
    }
    async function getKeepsByVaultId() {
      try {
        const vaultId = route.params.vaultId;
        logger.log(vaultId);
        await vaultsService.getKeepsByVaultId(vaultId);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getVaultById();
      getKeepsByVaultId();
    });
    return {
      activeVault: computed(() => AppState.activeVault),
      vaultKeeps: computed(() => AppState.keepsInVault),
      account: computed(() => AppState.account),

      async deleteVault(vaultId) {
        try {
          if (await Pop.confirm("Are you sure you want to delete this Vault?")) {
            await vaultsService.deleteVault(vaultId)
          }
        } catch (error) {
          Pop.error(error)
        }
      }
    };
  },
  components: { KeepCard, ActiveKeepCard, LargeModal, VaultKeepCard, SmallModal }
}
</script>


<style lang="scss" scoped>
.width-100 {
  width: 80vw;
  margin: 0px auto;
}

.card {
  --bs-card-bg: none !important;
  --bs-card-border-width: 0px !important;
  border: none;
  background: none;
}

.card-style {
  transition: all .2s ease-in-out;
}

.card-style:hover {
  cursor: pointer;
  transform: scale(1.04);
}

.vault-cont {
  width: 80vw;
  margin: 0px auto;
  columns: 4;
  column-gap: 10vh;
}

.cover-img {
  height: 20vh;
  width: 100%;
  border-radius: 8px;
}

.count-style {
  background-color: #DED6E9;
  padding: 6px 8px;
  border-radius: 12px;
}

.dropdown-border {
  border-bottom: 1px solid rgb(70, 70, 70);
  width: 80%;
  margin: 0 auto;
}

.drop-style {
  background-color: #DED6E9;
  border: 1.5px solid black;
}

.main-cont {
  width: 65vw;
  margin: 0px auto;
}

.text-shadow {
  text-shadow: 2px 2px 2px black;
}

.header-cont {
  width: 30vw;
  margin: 0px auto;

}
</style>