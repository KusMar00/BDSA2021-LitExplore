using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LitExplore.Repository;
public partial class Database
{
    /// <summary>
    /// The seed data comes from Google Scholar (https://scholar.google.com/).
    /// The seed data does not include users and projects since adding and
    /// removing these are part of the vertical slice.
    /// </summary>
    public static void Seed(LitExploreContext context)
    {
        context.Database.EnsureDeleted();
        // Clean migrations.
        var migrator = context.GetService<IMigrator>();
        migrator.Migrate("0");
        context.Database.Migrate();

        // Template for adding papers
        /*

        Author
            Author_GN_Surname = new() { GivenName = "", Surname = "" },
            Author_GN_Surname = new() { GivenName = "", Surname = "" };
        
        Paper PaperName = new()
        {
            Authors = new HashSet<Author>() { Author_GivenName_Surname },
            Name = @"",
            URL = @"",
            Abstract = @"",
            Citings = new List<Paper> {  }
        };
        context.Papers.Add(PaperName);
        
        */
        // Template for adding papers

        #region Coffee
        Author
            Author_P_Esquivel = new() { GivenName = "Patricia", Surname = "Esquivel" },
            Author_VM_Jimenez = new() { GivenName = "Victor M.", Surname = "Jimenez" };

        Paper Paper_Functional_Properties_Of_Coffee = new()
        {
            Authors = new HashSet<Author> { Author_P_Esquivel, Author_VM_Jimenez },
            Name = @"Functional properties of coffee and coffee by-products",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996911003449?casa_token=tdCQmafGfxcAAAAA:tKxOe9YNAwPLm6A_w-oKnGKZPLZu1Dug4RaZ68RKeDCfeEdjs_HFiJh0q5j-hwIEB6PBpXT0914",
            Abstract = @"Coffee, one of the most popular beverages, is consumed by millions of people every day. Traditionally, coffee beneficial effects have been attributed solely to its most intriguing and investigated ingredient, caffeine, but it is now known that other compounds also contribute to …",
        };
        context.Papers.Add(Paper_Functional_Properties_Of_Coffee);


        Author
            Author_A_Zuorro = new() { GivenName = "Antonio", Surname = "ZUORRO" },
            Author_R_Lavecchia = new() { GivenName = "Roberto", Surname = "Lavecchia" };

        Paper Paper_Spent_Coffee_Grounds = new()
        {
            Authors = new HashSet<Author>() { Author_A_Zuorro, Author_R_Lavecchia },
            Name = @"Spent coffee grounds as a valuable source of phenolic compounds and bioenergy",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0959652611005117?casa_token=N76EXWDZvMoAAAAA:9ryevfBm9sXLugCElAxj47CxgJS2XQ08c-LW04yZyYo2h9DRKtKSsH0xUhqL3APxHAD0Slz2taI",
            Abstract = @"Spent coffee grounds collected from coffee bars (SCG-1) or recovered from coffee capsules (SCG-2) were investigated as a potential source of phenolic compounds and energy. Preliminary characterization of these materials provided a total phenolic content of 17.75 mg …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Paper_Spent_Coffee_Grounds);


        Author
            Author_Y_Narita = new() { GivenName = "Y", Surname = "Narita" },
            Author_K_Inouye = new() { GivenName = "K", Surname = "Inouye" };

        Paper Review_On_Utilization_And_Composition_of_Coffee_Silverskin = new()
        {
            Authors = new HashSet<Author>() { Author_Y_Narita, Author_K_Inouye },
            Name = @"Review on utilization and composition of coffee silverskin",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0963996914000295?casa_token=2IWcGZxe2gQAAAAA:xZPHNHZgDB0snvQbAL1AlWQXTVXBjjG5R6Eh0SLgQz5ufhyVAQry_dOc9IpEMqMsXGkSEwx4",
            Abstract = @"Coffee is one of the most frequently consumed drinks in the world. Coffee silverskin (CS) is the only by-product produced during the coffee beans roasting process, and large amounts of CS are produced by roasters in coffee-consuming countries. However, methods for the …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Review_On_Utilization_And_Composition_of_Coffee_Silverskin);


        Author
            Author_JB_Essner = new() { GivenName = "Jerimy B.", Surname = "Essner" },
            Author_JA_Kist = new() { GivenName = "Jennifer A", Surname = "Kist" },
            Author_L_Polo_Parada = new() { GivenName = "Luis", Surname = "Polo-Parada" };

        Paper Paper_Artifacts_And_Errors = new()
        {
            Authors = new HashSet<Author>() { Author_JB_Essner, Author_JA_Kist, Author_L_Polo_Parada },
            Name = @"Artifacts and errors associated with the ubiquitous presence of fluorescent impurities in carbon nanodots",
            URL = @"https://www.academia.edu/download/55961585/2018_Artifact_and_Errors_associated_wit_Ubiquitous_presence_of_Fluorescent_impurities_in_Carbon_Nanodot.pdf",
            Abstract = @"Fluorescent carbon dots have attracted tremendous attention owing to their superlative optical properties which suggest opportunities for replacing conventional fluorescent materials in various application fields. Not surprisingly, the rapid pace of publication has …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Paper_Artifacts_And_Errors);


        Author
            Author_Marija_Ranic = new() { GivenName = "Marija", Surname = "Ranic" },
            Author_Marina_Nikolic = new() { GivenName = "Marina", Surname = "Nikolic" },
            Author_Marija_Pavlovic = new() { GivenName = "Marija", Surname = "Pavlovic" },
            Author_Aneta_Buntic = new() { GivenName = "Aneta", Surname = "Buntic" },
            Author_Slavica_SilerMarinkovic = new() { GivenName = "Slavica", Surname = "Siler-Marinkovic" },
            Author_Suzana_DimitrijevicBrankovic = new() { GivenName = "Suzana", Surname = "Dimitrijevic-Brankovic" };

        Paper Optimization_Of_Microwaveassisted_Extraction = new()
        {
            Authors = new HashSet<Author>() { Author_Marija_Ranic, Author_Marina_Nikolic, Author_Marija_Pavlovic, Author_Aneta_Buntic, Author_Slavica_SilerMarinkovic, Author_Suzana_DimitrijevicBrankovic },
            Name = @"Optimization of microwave-assisted extraction of natural antioxidants from spent espresso coffee grounds by response surface methodology",
            URL = @"https://www.sciencedirect.com/science/article/pii/S095965261400537X?casa_token=1lyRzLyglDoAAAAA:VuWYbjcyByJosGFptXcla5QmDSd9Tki-WBgfJb44AShJoIcf7HxBVlxvYImVgMR7Qg2EpUzZ",
            Abstract = @"Espresso spent coffee grounds (SCG) that is a waste material abundantly produced by restaurants, cafeterias and in domestic environment could be used as a low-cost and rich source of valuable polyphenol compounds. The benefit would be twofold: extraction of …",
            Citings = new List<Paper> { Paper_Functional_Properties_Of_Coffee }
        };
        context.Papers.Add(Optimization_Of_Microwaveassisted_Extraction);


        Author
            Author_R_Campos_Vega = new() { GivenName = "Rocio", Surname = "Campos-Vega" },
            Author_G_Loarca_Pina = new() { GivenName = "Guadalupe", Surname = "Loarca-Piña" };

        Paper Paper_Spent_Coffee_Grounds_Review = new()
        {
            Authors = new HashSet<Author>() { Author_R_Campos_Vega, Author_G_Loarca_Pina },
            Name = @"Spent coffee grounds: A review on current research and future prospects",
            URL = @"https://www.sciencedirect.com/science/article/pii/S0924224415001193?casa_token=ej7n7x4S764AAAAA:uprQrezreHFr0IDoxZRUkR3ZTsn9jlsfTdUEfYX65tz1ynJz7ixm4_EiFXZhnhNBis9vEaDRHN8",
            Abstract = @"Spent coffee ground (SCG) contains large amounts of organic compounds (ie fatty acids, amino acids, polyphenols, minerals and polysaccharides) that justify its valorization. Earlier innovation explored the extraction of specific components such as oil, flavor, terpenes, and …",
            Citings = new List<Paper> { Paper_Spent_Coffee_Grounds }
        };
        context.Papers.Add(Paper_Spent_Coffee_Grounds_Review);


        Author
            Author_A_Panusa = new() { GivenName = "Alessia", Surname = "Panusa" },
            // A Zuorro already exists
            // R Lavecchia already exists
            Author_G_Marrosu = new() { GivenName = "Giancarlo", Surname = "Marrosu" },
            Author_R_Petrucci = new() { GivenName = "Rita", Surname = "Petrucci" };

        Paper Paper_Recovery_Of_Natural_Antioxidants = new()
        {
            Authors = new HashSet<Author>() { Author_A_Panusa, Author_A_Zuorro, Author_R_Lavecchia, Author_G_Marrosu, Author_R_Petrucci },
            Name = @"Recovery of natural antioxidants from spent coffee grounds",
            URL = @"https://pubs.acs.org/doi/abs/10.1021/jf4005719",
            Abstract = @"Spent coffee grounds (SCG) were extracted with an environmentally friendly procedure and analyzed to evaluate the recovery of relevant natural antioxidants for use as nutritional supplements, foods, or cosmetic additives. SCG were characterized in terms of their total …",
            Citings = new List<Paper>() { Paper_Spent_Coffee_Grounds }
        };
        context.Papers.Add(Paper_Recovery_Of_Natural_Antioxidants);
        #endregion

        #region Bioluminescence
        Author
            Author_Thérèse_Wilson = new() { GivenName = "Thérèse", Surname = "Wilson" },
            Author_JW_Hastings = new() { GivenName = "J. Woodland", Surname = "Hastings" };
        
        Paper Paper_Bioluminescence = new()
        {
            Authors = new HashSet<Author>() { Author_Thérèse_Wilson, Author_JW_Hastings },
            Name = @"Bioluminescence",
            URL = @"https://www.annualreviews.org/doi/abs/10.1146/annurev.cellbio.14.1.197",
            Abstract = @"Bioluminescence has evolved independently many times; thus the responsible genes are unrelated in bacteria, unicellular algae, coelenterates, beetles, fishes, and others. Chemically, all involve exergonic reactions of molecular oxygen with different substrates …",
            Citings = new List<Paper> {  }
        };
        context.Papers.Add(Paper_Bioluminescence);

        Author
            Author_CE_Outten = new() { GivenName = "Caryn E.", Surname = "Outten" },
            Author_TV_OHalloran = new() { GivenName = "Thomas V.", Surname = "O'Halloran" };
        
        Paper Paper_Femtolar_sensitivity = new()
        {
            Authors = new HashSet<Author>() { Author_CE_Outten, Author_TV_OHalloran },
            Name = @"Femtomolar sensitivity of metalloregulatory proteins controlling zinc homeostasis",
            URL = @"http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.933.2741&rep=rep1&type=pdf",
            Abstract = @"Intracellular zinc is thought to be available in a cytosolic pool of free or loosely bound Zn (II) ions in the micromolar to picomolar range. To test this, we determined the mechanism of zinc sensors that control metal uptake or export in Escherichia coli and calibrated their response …",
            Citings = new List<Paper> { Paper_Bioluminescence }
        };
        context.Papers.Add(Paper_Femtolar_sensitivity);

        Author
            Author_KP_Carter = new() { GivenName = "Kyle P.", Surname = "Carter" },
            Author_AM_Young = new() { GivenName = "Alexandra M.", Surname = "Young" },
            Author_AE_Palmer = new() { GivenName = "Amy E.", Surname = "Palmer" };
        
        Paper Paper_Fluorescent_Sensors = new()
        {
            Authors = new HashSet<Author>() { Author_KP_Carter, Author_AM_Young, Author_AE_Palmer },
            Name = @"Fluorescent sensors for measuring metal ions in living systems",
            URL = @"https://pubs.acs.org/doi/full/10.1021/cr400546e",
            Abstract = @"All life forms have an absolute requirement for metals, as metals play critical roles in fundamental processes, including osmotic regulation, catalysis, metabolism, biomineralization, and signaling. Group I and II metals (alkali and alkaline earth metals such …",
            Citings = new List<Paper> { Paper_Femtolar_sensitivity }
        };
        context.Papers.Add(Paper_Fluorescent_Sensors);

        Author
            Author_TR_Ray = new() { GivenName = "Tyler R.", Surname = "Ray" },
            Author_Jungil_Choi = new() { GivenName = "Jungil", Surname = "Choi" },
            Author_AJ_Bandodkar = new() { GivenName = "Amay J.", Surname = "Bandodkar" },
            Author_Siddharth_Krishnan = new() { GivenName = "Siddharth", Surname = "Krishnan" },
            Author_Philipp_Gutruf = new() { GivenName = "Philipp", Surname = "Gutruf" },
            Author_Limei_Tian = new() { GivenName = "Limei", Surname = "Tian" },
            Author_Roozbeh_Ghaffari = new() { GivenName = "Roozbeh", Surname = "Ghaffari" },
            Author_JA_Rogers = new() { GivenName = "John A.", Surname = "Rogers" };
        
        Paper Paper_BioIntegrated_Weatable_Systems = new()
        {
            Authors = new HashSet<Author>() { Author_TR_Ray, Author_Jungil_Choi, Author_AJ_Bandodkar, Author_Siddharth_Krishnan, Author_Philipp_Gutruf, Author_Limei_Tian, Author_Roozbeh_Ghaffari, Author_JA_Rogers },
            Name = @"Bio-integrated wearable systems: a comprehensive review",
            URL = @"http://rogersgroup.northwestern.edu/files/2019/chemrevpub.pdf",
            Abstract = @"Bio-integrated wearable systems can measure a broad range of biophysical, biochemical, and environmental signals to provide critical insights into overall health status and to quantify human performance. Recent advances in material science, chemical analysis …",
            Citings = new List<Paper> { Paper_Fluorescent_Sensors }
        };
        context.Papers.Add(Paper_BioIntegrated_Weatable_Systems);

        Author
            Author_Di_Wu = new() { GivenName = "Di", Surname = "Wu" },
            Author_AC_Sedgwick = new() { GivenName = "Adam C.", Surname = "Sedgwick" },
            Author_Thorf_Gunnla = new() { GivenName = "Thorfinnur", Surname = "Gunnlaugsson" },
            Author_EU_Akkaya = new() { GivenName = "Engin U.", Surname = "Akkaya" },
            Author_Juyo_Yoon = new() { GivenName = "Juyoung", Surname = "Yoon" },
            Author_TD_James = new() { GivenName = "Tony D.", Surname = "James" };
        
        Paper Paper_Fluorescent_Chemosensors = new()
        {
            Authors = new HashSet<Author>() { Author_Di_Wu, Author_AC_Sedgwick, Author_Thorf_Gunnla, Author_EU_Akkaya, Author_Juyo_Yoon, Author_TD_James },
            Name = @"Fluorescent chemosensors: the past, present and future",
            URL = @"https://pubs.rsc.org/en/content/articlehtml/2017/cs/c7cs00240h",
            Abstract = @"Fluorescent chemosensors for ions and neutral analytes have been widely applied in many diverse fields such as biology, physiology, pharmacology, and environmental sciences. The field of fluorescent chemosensors has been in existence for about 150 years. In this time, a …",
            Citings = new List<Paper> { Paper_Fluorescent_Sensors }
        };
        context.Papers.Add(Paper_Fluorescent_Chemosensors);

        Author
            Author_MR_Broadley = new() { GivenName = "Martin R.", Surname = "Broadley" },
            Author_PJ_White = new() { GivenName = "Phillip J.", Surname = "White" },
            Author_JP_Hammond = new() { GivenName = "John P.", Surname = "Hammond" },
            Author_Ivan_Zelko = new() { GivenName = "Ivan", Surname = "Zelko" },
            Author_Alexander_Lux = new() { GivenName = "Alexander", Surname = "Lux" };
        
        Paper Paper_Zinc_In_Plants = new()
        {
            Authors = new HashSet<Author>() { Author_MR_Broadley, Author_PJ_White, Author_JP_Hammond, Author_Ivan_Zelko, Author_Alexander_Lux },
            Name = @"Zinc in plants",
            URL = @"https://nph.onlinelibrary.wiley.com/doi/pdf/10.1111/j.1469-8137.2007.01996.x",
            Abstract = @"Zinc (Zn) is an essential component of thousands of proteins in plants, although it is toxic in excess. In this review, the dominant fluxes of Zn in the soil–root–shoot continuum are described, including Zn inputs to soils, the plant availability of soluble Zn2+ at the root …",
            Citings = new List<Paper> { Paper_Femtolar_sensitivity }
        };
        context.Papers.Add(Paper_Zinc_In_Plants);

        Author
            Author_DH_Nies = new() { GivenName = "Dietrich H.", Surname = "Nies" };
        
        Paper Paper_EffluxMediated_Heavy_Metal = new()
        {
            Authors = new HashSet<Author>() { Author_DH_Nies },
            Name = @"Efflux-mediated heavy metal resistance in prokaryotes",
            URL = @"https://academic.oup.com/femsre/article/27/2-3/313/615199",
            Abstract = @"What makes a heavy metal resistant bacterium heavy metal resistant? The mechanisms of action, physiological functions, and distribution of metal-exporting proteins are outlined, namely: CBA efflux pumps driven by proteins of the resistance–nodulation–cell division …",
            Citings = new List<Paper> { Paper_Femtolar_sensitivity }
        };
        context.Papers.Add(Paper_EffluxMediated_Heavy_Metal);

        Author
            Author_Anthony_Lau = new() { GivenName = "Anthony", Surname = "Lau" },
            Author_Michael_Tymianski = new() { GivenName = "Michael", Surname = "Tymianski" };
        
        Paper Paper_Glutamate_Receptors = new()
        {
            Authors = new HashSet<Author>() { Author_Anthony_Lau, Author_Michael_Tymianski },
            Name = @"Glutamate receptors, neurotoxicity and neurodegeneration",
            URL = @"https://link.springer.com/article/10.1007/s00424-010-0809-1",
            Abstract = @"Glutamate excitotoxicity is a hypothesis that states excessive glutamate causes neuronal dysfunction and degeneration. As glutamate is a major excitatory neurotransmitter in the central nervous system (CNS), the implications of glutamate excitotoxicity are many and far …",
            Citings = new List<Paper> { Paper_Femtolar_sensitivity }
        };
        context.Papers.Add(Paper_Glutamate_Receptors);

        Author
            Author_GD_Scholes = new() { GivenName = "Gregory D.", Surname = "Scholes" };
        
        Paper Paper_LongRange_resonance = new()
        {
            Authors = new HashSet<Author>() { Author_GD_Scholes },
            Name = @"Long-range resonance energy transfer in molecular systems",
            URL = @"http://www.bmo.physik.uni-muenchen.de/~gilch/mol_dyn_08/reader/ann_physchem_54_2003_57.pdf",
            Abstract = @"The current state of understanding of molecular resonance energy transfer (RET) and recent developments in the field are reviewed. The development of more general theoretical approaches has uncovered some new principles underlying RET processes. ...",
            Citings = new List<Paper> { Paper_Bioluminescence }
        };
        context.Papers.Add(Paper_LongRange_resonance);

        Author
            Author_MK_So = new() { GivenName = "Min-Kyung", Surname = "So" },
            Author_Chenjie_Xu = new() { GivenName = "Chenjie", Surname = "Xu" },
            Author_AM_Loening = new() { GivenName = "Andreas M.", Surname = "Loening" },
            Author_SS_Gambhir = new() { GivenName = "Sanjiv S.", Surname = "Gambhir" },
            Author_J_Rao = new() { GivenName = "Jianghong", Surname = "Rao" };
        
        Paper Paper_SelfIlluminating_Quantom = new()
        {
            Authors = new HashSet<Author>() { Author_MK_So, Author_Chenjie_Xu, Author_AM_Loening, Author_SS_Gambhir, Author_J_Rao },
            Name = @"Self-illuminating quantum dot conjugates for in vivo imaging",
            URL = @"https://www.researchgate.net/profile/Andreas-Loening/publication/7275183_Self-Illuminating_Quantum_Dot_Conjugates_for_In_Vivo_Imaging/links/568d79ab08aef987e565f833/Self-Illuminating-Quantum-Dot-Conjugates-for-In-Vivo-Imaging.pdf",
            Abstract = @"Fluorescent semiconductor quantum dots hold great potential for molecular imaging in vivo 1, 2, 3, 4, 5. However, the utility of existing quantum dots for in vivo imaging is limited because they require excitation from external illumination sources to fluoresce, which results …",
            Citings = new List<Paper> { Paper_Bioluminescence }
        };
        context.Papers.Add(Paper_SelfIlluminating_Quantom);

        Author
            Author_SHD_Haddock = new() { GivenName = "Steven H.D.", Surname = "Haddock" },
            Author_MA_Moline = new() { GivenName = "Mark A.", Surname = "Moline" },
            Author_JF_Case = new() { GivenName = "James F.", Surname = "Case" };
        
        Paper Paper_Bioluminescence_In_The_Sea = new()
        {
            Authors = new HashSet<Author>() { Author_SHD_Haddock, Author_MA_Moline, Author_JF_Case },
            Name = @"Bioluminescence in the sea",
            URL = @"http://digitalcommons.calpoly.edu/cgi/viewcontent.cgi?article=1186&context=bio_fac",
            Abstract = @"Bioluminescence spans all oceanic dimensions and has evolved many times—from bacteria to fish—to powerfully influence behavioral and ecosystem dynamics. New methods and technology have brought great advances in understanding of the molecular basis of …",
            Citings = new List<Paper> { Paper_Bioluminescence }
        };
        context.Papers.Add(Paper_Bioluminescence_In_The_Sea);
        #endregion

        context.SaveChanges();
    }
}
