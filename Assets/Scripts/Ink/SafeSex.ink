VAR chose_protection = false

->intro
=== intro ===

You're spending time with someone you trust. Things are getting intimate.

They pause and ask, "Hey, before we go any further... are we using protection?"

What do you want to do?

+ "Yes, let's use an external condom."
    ~ chose_protection = true
    -> external_condom_info
+ "Condoms aren’t for me. Are there other options?"
    -> explore_other_methods
+ "Let's skip protection."
    -> no_protection_consequence

=== external_condom_info ===
Do you want to try putting one on correctly?

+ Yes, let’s play the condom mini-game!
    -> condom_game

=== condom_game ===
# MINIGAME_CONDOM_SIZING
[Starting condom sizing mini-game...]
-> waiting_after_mini_game

=== waiting_after_mini_game ===
[You return after completing the sizing game, ready to continue safely.]

-> safe_outcome("correctly sized condom")

=== explore_other_methods ===
You tell your partner you'd rather not use a condom, but you're still interested in being safe.

They respond:  
"That's totally fine! We can explore other methods — as long as we stay safe."

+ "What are the other options?"
    -> go_to_clinic
+ "Eh, never mind, let’s just skip it."
    -> no_protection_consequence

=== go_to_clinic ===
# SWITCH_BACKGROUND_CLINIC
You suggest looking into other options.  
Your partner agrees, and you both visit a local clinic for advice.

At the clinic, a nurse welcomes you.

Nurse: "Welcome! There are a few different types of birth control methods to consider.  
Let me briefly explain the main categories."

+ "Hormonal Methods"
    -> hormonal_methods_intro
+ "Barrier Methods"
    -> barrier_methods_intro
+ "Long-Acting Reversible Contraceptives (LARCs)"
    -> larc_intro
+ "Emergency Contraceptives"
    -> emergency_intro


=== hormonal_methods_intro ===
Nurse: "Hormonal methods release hormones into your body to prevent pregnancy.  
This includes the pill, patch, shot, and vaginal ring."

What would you like to do next?

+ "Learn about hormonal methods"
    -> clinic_hormonal_methods
+ "Play the vaginal ring mini-game"
    -> vaginal_ring_game
+ "Go back to method categories"
    -> go_to_clinic
+ "I'm ready to decide"
    -> ready_to_choose


=== barrier_methods_intro ===
Nurse: "Barrier methods block sperm from reaching the egg.  
This includes external/internal condoms, diaphragm, and cervical cap."

What would you like to do next?

+ "Learn about barrier methods"
    -> clinic_barrier_methods
+ "Play the condom mini-game!"
    -> condom_game
+ "Go back to method categories"
    -> go_to_clinic
+ "I'm ready to decide"
    -> ready_to_choose

=== larc_intro ===
Nurse: "LARCs are long-acting and don't require daily action.  
They include IUDs and implants."

What would you like to do next?

+ "Learn about LARC methods"
    -> clinic_larc_methods
+ "Go back to method categories"
    -> go_to_clinic
+ "I'm ready to decide"
    -> ready_to_choose


=== emergency_intro ===
Nurse: "Emergency contraception is used after unprotected sex to reduce risk of pregnancy."

What would you like to do next?

+ "Learn about emergency methods"
    -> clinic_emergency_methods
+ "Go back to method categories"
    -> go_to_clinic
+ "I'm ready to decide"
    -> ready_to_choose

=== clinic_hormonal_methods ===
Which hormonal method would you like to learn about?

+ "The Pill"
    -> learn_pill
+ "Vaginal Ring"
    -> learn_vaginal_ring
+ "Play the vaginal ring mini-game"
    -> vaginal_ring_game
+ "Go back"
    -> hormonal_methods_intro

=== clinic_barrier_methods ===
Which barrier method would you like to learn about?

+ "External condom"
    -> learn_external_condom
+ "Play the condom mini-game"
    -> condom_game
+ "Diaphragm"
    -> learn_diaphragm
+ "Go back"
    -> barrier_methods_intro

=== clinic_larc_methods ===
Which LARC method would you like to learn about?

+ "IUD"
    -> learn_iud
+ "Go back"
    -> larc_intro
=== clinic_emergency_methods ===
Which emergency method would you like to learn about?

+ "Emergency contraception (pill)"
    -> learn_emergency_contraception
+ "Go back"
    -> emergency_intro


=== RETURN_MENU ===
What would you like to do next?

+ "Learn about another method"
    -> go_to_clinic
+ "I'm ready to decide"
    -> ready_to_choose


=== learn_pill ===
Nurse: "The pill is a small tablet you take daily. It releases hormones that prevent ovulation.  
It’s one of the most common hormonal methods and is 99% effective when taken properly."

-> RETURN_MENU

=== learn_external_condom ===
Nurse: "External condoms are worn on the penis during sex to prevent sperm from entering the vagina.  
They are widely available, affordable, and also provide protection against STIs."

Would you like to try putting one on correctly?

+ "Yes, let’s play the condom mini-game!"
    -> condom_game
+ "No thanks, just wanted to learn."
    -> clinic_barrier_methods

=== learn_iud ===
Nurse: "The IUD is a small T-shaped device that is inserted into the uterus.  
It’s a long-acting method that can last between 3 and 10 years, depending on the type. It’s very effective and doesn’t require daily action."

-> RETURN_MENU

=== learn_vaginal_ring ===
Nurse: "The vaginal ring is a flexible, small ring that you place inside your vagina.  
It releases hormones to prevent pregnancy, and you replace it every month. It’s easy to use and doesn’t require daily attention."

Would you like to practice using the vaginal ring correctly?

+ "Yes, let’s try it out!"
    -> vaginal_ring_game
+ "No, I’ll just learn about it for now."
-> RETURN_MENU

=== vaginal_ring_game ===
# MINIGAME_VAGINAL_RING
[Starting vaginal ring placement mini-game...]
-> waiting_after_ring_game

=== waiting_after_ring_game ===
[You return after completing the vaginal ring mini-game, feeling more confident!]

-> RETURN_MENU

=== learn_diaphragm ===
Nurse: "The diaphragm is a small, flexible cup that you insert into your vagina.  
It covers the cervix and must be used with spermicide. It can be used on demand and is very effective when used correctly."

-> RETURN_MENU

=== learn_emergency_contraception ===
Nurse: "Emergency contraception (like the morning-after pill) can be used after unprotected sex.  
It works by delaying or preventing ovulation. It’s not meant for regular use but can prevent pregnancy if used within 72 hours."

-> RETURN_MENU

=== ready_to_choose ===
You and your partner discuss your options based on what you've learned.

Nurse: "Great! Using any protection is better than none. Stay safe and check in with each other."

-> safe_outcome("alternative method")


=== no_protection_consequence ===
You and your partner proceed without any protection.

A few days later, you notice some discomfort and decide to get tested.

-> sti_outcome

=== safe_outcome(method) ===
Using {method} helped make the experience safer and more respectful.

Your partner checks in with you afterward:  
"How are you feeling about everything?"

+ "Good. I’m glad we took precautions."
    Partner: "Same. It’s nice to feel safe and respected."
    -> end_scene
+ "I’d like to learn even more for the future."
    -> learn_more_safe_methods

=== learn_more_safe_methods ===
You look up more information or visit a local clinic to ask questions.

A friendly nurse greets you:  
"Happy to help! What would you like to know more about?"

+ "What STIs should I know about?"
    -> info_stis
+ "What are barrier methods besides condoms?"
    -> info_barriers
+ "What about long-term protection?"
    -> info_longterm
+ "I think I’m good, thanks."
    -> end_scene

=== info_stis ===
The nurse explains:  
"There are many STIs — some like chlamydia or gonorrhea can be treated easily, while others like herpes or HIV require ongoing management."

"Testing regularly is key — especially with new partners."

+ "What are symptoms I should watch for?"
    -> sti_symptoms
+ "Back to the other questions."
    -> learn_more_safe_methods

=== sti_symptoms ===
"Many STIs have no symptoms — but some signs include pain, itching, discharge, or bumps. That’s why testing is important even if you feel fine."

-> learn_more_safe_methods

=== info_barriers ===
"There are internal condoms, dental dams for oral sex, and finger cots. All are good ways to protect yourself and your partner."

-> learn_more_safe_methods

=== info_longterm ===
"Long-term methods like birth control pills, IUDs, implants, or patches prevent pregnancy — but not STIs. You can pair them with barriers for extra safety."

-> learn_more_safe_methods

=== sti_outcome ===
You visit a clinic after noticing something felt off.

A nurse runs some tests and gently tells you:
"You tested positive for chlamydia — it's treatable, and you caught it early."

You’re given antibiotics and a chance to ask questions.

+ "How could I have prevented this?"
    -> prevention_tips
+ "What do I do now?"
    -> treatment_plan
+ "Will this affect me long-term?"
    -> longterm_effects

=== prevention_tips ===
"Barrier methods like condoms and dental dams reduce the risk significantly. Regular testing and open communication also help."

-> sti_outcome_end

=== treatment_plan ===
"You’ll take medication and avoid sex for a week until it clears. We recommend your partner gets tested too."

-> sti_outcome_end

=== longterm_effects ===
"Most people recover fully if it’s treated early. If ignored, it could cause more serious issues — but you acted quickly."

-> sti_outcome_end

=== sti_outcome_end ===
The experience leaves you better informed.  
You now know how to take action, protect yourself, and support others.

-> end_scene

=== end_scene ===

Thanks for playing.  
No shame, just growth.  
Safe sex is about respect — for your body and your choices.

-> END


