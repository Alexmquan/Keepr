<template>
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <!-- SECTION MODAL BODY -->
        <div class="modal-body text-dark no-pad rounded">
          <slot name="body"></slot>
        </div>
      </div>
    </div>
  </div>
</template>


<script>


export default {
  setup() {

    return {
    }
  }
}
</script>


<style lang="scss" scoped>
@media screen and (min-width: 768px) {
  .no-pad {
    padding: 0;
  }

  .no-border {
    border: white;
    align-items: normal;
  }

}

@media screen and (max-width: 768px) {
  .no-pad {
    padding: 0;
  }
}
</style>