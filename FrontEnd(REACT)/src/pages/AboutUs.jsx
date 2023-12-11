import { shadowStyle } from 'features/common/Styles'

function AboutUs() {
  return (
    <div className="w-full mt-8">
      <div className="w-[1232px] mx-auto flex items-stretch gap-x-4">
        <div
          className="flex-1 grow-[4] bg-white rounded-lg  h-full"
          style={shadowStyle}
        >
          <div className="flex flex-col items-start   text-sm font-semibold text-gray-500 ">
            <div className="w-full h-12 flex items-center bg-[#F3F0FE] rounded-t-lg">
              <span className="mx-6 text-primary-brand-color font-semibold">
                Hakkımızda
              </span>
            </div>
            <div className="w-full  h-12 flex items-center ">
              <span className="mx-6">Kurucularımız</span>
            </div>
            <div className="w-[85%]    bg-gray-200  h-[0.1em] mx-auto  flex items-center"></div>
            <div className="h-12 flex items-center">
              <span className="mx-6">İletişim</span>
            </div>
          </div>
        </div>
        <div className="flex-1 grow-[12]  bg-white rounded-lg p-10 " style={shadowStyle}>
          <h1 className="text-2xl text-primary-brand-color font-semibold">
            Hakkımızda
          </h1>
          <br />


          Getir Bi Mutluluk
          <br />
          <br />
          Binlerce ürünü dakikalar içinde, gece
          gündüz, dilediğiniz yere getiriyoruz!
          <br />
          <br />
          Zamanın kıymetini biliyoruz,
          hayatınızı kolaylaştırıyoruz. Her geçen gün genişlettiğimiz ürün
          yelpazesi sayesinde bebek bezinden, çikolata, cips ve içeceklere,
          tıraş köpüğü, deterjan ve deodoranttan kedi-köpek mamasına, pilden
          ampule, tüm ihtiyaçlarınız için anında, olduğunuz yerdeyiz. Getir’le
          en çok tükettiğiniz ürünleri, GetirBüyük’le haftalık ya da aylık
          market alışverişinizi, GetirYemek’le ise dilediğiniz yemeği dakikalar
          içinde size ulaştırıyoruz. GetirSu servisimiz ve sizler için
          yarattığımız Kuzeyden markamızla Pazar günü de dahil, gece gündüz
          damacana su teslimatı yapıyoruz. İhtiyacınızı karşılamak için evden
          çıkmanıza gerek yok; bakkala, markete, restorana gitmenize gerek yok,
          biz varız. Neden Getir? Dakikalar İçinde Teslimat Çok sayıdaki depo,
          araç ve motokuryelerimizle hizmetinizdeyiz. İhtiyaç ürünlerinizi ve
          market alışverişinizi dakikalar içinde ayağınıza getiriyoruz. Canlı
          Sipariş Takibi Siparişinizi verdikten sonra kuryenin gelişini
          haritadan izleyebilir, ürünlerinizin kaç dakikada sizde olacağını
          bilebilirsiniz. GetirYemek Sevdiğiniz restoranlardan pizza, hamburger,
          lahmacun, kebap, döner, tatlı ve daha birçok yemek siparişi verebilir,
          siparişinizi takip edebilirsiniz. Ayrıca ‘Getir Getirsin’ seçeneği ile
          sıcak yemeğinizi size getiren kuryemizin konumunu haritada
          görebilirsiniz. Dijital ve Kapıda Ödeme Ödemeler iki şekilde
          gerçekleşiyor: dijital ve kapıda ödeme. Dijital ödeme için yalnızca
          bir sefer sisteme tanımladığınız banka veya kredi kartınız ya da
          elinizde bulunan İstanbul Kartınız yeterli! Cüzdana ihtiyaç yok!
          Üstelik kredi kartı bilgilerinizi Getir dahil kimse göremez. Kart
          bilgileriniz Mastercard'ın ödeme altyapısı Masterpass ya da BKM
          (Bankalararası Kart Merkezi) tarafından korunur. Kapıda ödeme
          özelliğimiz ise GetirYemek’ten ‘Restoran Getirsin’ seçeneği ile
          verdiğiniz siparişlere özel. Bu seçenek ile, restorana ait kuryenin
          getireceği yemeğinizin ödemesini pos cihazı aracılığıyla kapıda
          yapabilirsiniz. GetirYemek’ten ‘Restoran Getirsin’ seçeneği ile
          verdiğiniz siparişlerinizi yemek kartlarıyla da kapıda temassız
          ödeyebilirsiniz. Gece Gündüz Servis Market, bakkal kapansa da biz
          Getir'de gece gündüz demiyoruz, getiriyoruz. İletişim Bilgileri Adres:
          Etiler Mah. Tanburi Ali Efendi Sk. No:13 GetirOfis, Etiler,
          Beşiktaş/İstanbul E-Posta: info@getir.com Müşteri hizmetleri: 0850 532
          50 50 Ticari Ünvan: Getir Perakende Lojistik A.Ş. Mersis No:
          0394048265800010 Sicil No: 969158-0 Vergi Dairesi/No:
          Beşiktaş/3940482658 KEP Adresi: getir@hs01.kep.tr
        </div>
      </div>
    </div>
  )
}

export default AboutUs