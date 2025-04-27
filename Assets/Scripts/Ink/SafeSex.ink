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
Do you want to find the right size?

+ Yes, let’s play the sizing game!
    -> condom_game
    
+ Just use a standard one.
    -> safe_outcome("external condom")

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
    -> alternative_methods
+ "Eh, never mind, let’s just skip it."
    -> no_protection_consequence

=== alternative_methods ===
There are several other ways to protect yourself:

• Internal condoms  
• Dental dams  
• Mutual STI testing and barrier methods  
• Abstaining from high-risk activities

You and your partner decide to talk about what works best for both of you.

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
