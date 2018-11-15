//
//  DeviceExtension.swift
//  DinnerSystem
//
//  Created by Sean on 2018/3/8.
//  Copyright © 2018年 Sean.Inc. All rights reserved.
//

import Foundation

import UIKit

extension UIDevice {
    enum DevicePlatform: String {
        case other = "Old Device"
        case iPhone6S = "iPhone 6S"
        case iPhone6SPlus = "iPhone 6S Plus"
        case iPhone7 = "iPhone 7"
        case iPhone7Plus = "iPhone 7 Plus"
        case iPhone8 = "iPhone 8"
        case iPhone8Plus = "iPhone 8 Plus"
        case iPhoneX = "iPhone X"
    }
    
    var platform: DevicePlatform {
        get {
            var sysinfo = utsname()
            uname(&sysinfo)
            let platform = String(bytes: Data(bytes: &sysinfo.machine, count: Int(_SYS_NAMELEN)), encoding: .ascii)!.trimmingCharacters(in: .controlCharacters)
            switch platform {
            case "iPhone10,1", "iPhone10,4":
                return .iPhone8
            case "iPhone10,2", "iPhone10,5":
                return .iPhone8Plus
            case "iPhone10,3", "iPhone10,6":
                return .iPhoneX
            case "iPhone9,2", "iPhone9,4":
                return .iPhone7Plus
            case "iPhone9,1", "iPhone9,3":
                return .iPhone7
            case "iPhone8,2":
                return .iPhone6SPlus
            case "iPhone8,1":
                return .iPhone6S
            default:
                return .other
            }
        }
    }
    
    var hasTapticEngine: Bool {
        get {
            return platform == .iPhone6S || platform == .iPhone6SPlus
        }
    }
    
    var hasHapticFeedback: Bool {
        get {
            return platform == .iPhone7 || platform == .iPhone7Plus || platform == .iPhone8 || platform == .iPhone8Plus || platform == .iPhoneX
        }
    }
}
